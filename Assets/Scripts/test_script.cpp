#include <algorithm>
#include <cstring>
#include <iostream>
#include <map>
#include <queue>
#include <set>
#include <vector>

namespace Constants {
const size_t kLen = 1'000'000;  // just a number from task...
const ssize_t kAlphabetSize = 26;
}  // namespace Constants
namespace Common {
using namespace Constants;
using std::cin;
using std::cout;
using std::map;
using std::max;
using std::min;
using std::set;
using std::string;
using std::vector;
}  // namespace Common

struct AK {
  struct Node {
    int edges[Constants::kAlphabetSize] = {0};
    int go[Constants::kAlphabetSize] = {0};
    int term = -1;
    int compressed = -1;
    int link = 0;
  };
  std::vector<Node> ver;  // ~ vertices
  std::vector<int> wi;    // ~ words info

  void AddWord(std::string& str) {
    using namespace Common;
    size_t num = 0;
    for (size_t ind = 0; ind < str.size(); ++ind) {
      if ((num >= ver.size()) || (ver[num].edges[str[ind] - 'a'] == 0)) {
        ver[num].edges[str[ind] - 'a'] = ver.size();
        num = ver.size();
        ver.push_back({});
      } else {
        num = ver[num].edges[str[ind] - 'a'];
      }
    }
    wi.push_back(str.size());
    // positive shows length, <=0 links to the exiting word
    if (ver[num].term == -1) {
      ver[num].term = wi.size() - 1;
    } else {
      wi.back() = -ver[num].term;
    }
  }

  void ProcessNode(int par, std::deque<int>& lst) {
    // par ~ parent, lst ~ list (queue)
    using namespace Common;
    for (int ch = 0; ch < kAlphabetSize; ++ch) {
      int num = ver[par].edges[ch];
      if (num == 0) {
        continue;  // I dont have such edge
      }
      ver[num].link = par == 0 ? 0 : ver[ver[par].link].go[ch];
      for (int ch = 0; ch < kAlphabetSize; ++ch) {
        int next = ver[num].edges[ch];
        ver[num].go[ch] = next == 0 ? ver[ver[num].link].go[ch] : next;
      }
      int prev = ver[num].link;
      ver[num].compressed = ver[prev].term == -1 ? ver[prev].compressed : prev;
      lst.push_back(num);
    }
  }
  void FinishInit() {
    using namespace Common;
    ver[0].compressed = -1;
    ver[0].link = -1;
    for (int ch = 0; ch < kAlphabetSize; ++ch) {
      ver[0].go[ch] = max(0, ver[0].edges[ch]);
    }
    std::deque<int> lst;
    lst.push_back(0);
    while (!lst.empty()) {
      int par = lst.front();
      lst.pop_front();
      ProcessNode(par, lst);
    }
  }

  AK(size_t cnt = 0) {
    using namespace Common;
    ver.reserve(kLen);
    ver.push_back({});  // root
    wi.reserve(cnt);
    string inp;
    for (size_t ind = 0; ind < cnt; ++ind) {
      cin >> inp;
      AddWord(inp);
    }
    FinishInit();
  }

  std::map<int, std::vector<int>> Seek(std::string& str) {
    using namespace Common;
    map<int, vector<int>> ans;
    int num = 0;
    int ind = -1;
    for (char ch : str) {
      ++ind;
      num = ver[num].go[ch - 'a'];
      int tmp = num;
      int tmp_term = ver[tmp].term;
      if (tmp_term != -1) {
        ans[tmp_term].push_back(ind + 1 - wi[tmp_term]);
      }
      tmp = ver[tmp].compressed;
      while (tmp > 0) {
        tmp_term = ver[tmp].term;
        ans[tmp_term].push_back(ind + 1 - wi[tmp_term]);
        tmp = ver[tmp].compressed;
      }
    }
    for (auto& vec : ans) {
      std::sort(vec.second.begin(), vec.second.end());
    }
    return ans;
  }
};

int main() {
  using namespace Common;
  string str;
  cin >> str;
  int words_cnt;
  cin >> words_cnt;
  AK ak(words_cnt);
  auto ans = ak.Seek(str);
  for (int ind = 0; ind < words_cnt; ++ind) {
    auto& vec = ans[ak.wi[ind] <= 0 ? -ak.wi[ind] : ind];
    cout << vec.size() << ' ';
    for (auto ind : vec) {
      cout << ind + 1 << ' ';
    }
    cout << '\n';
  }
}
