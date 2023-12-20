using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    const int _ChunkX = 17;
    const int _ChunkY = 17;

    public List<CellRef> RefObjs;
    public class Chunk {
        private int fx, fy, sx, sy;
        private int [,] _map;
        private List<GameObject> _view; 
        public Chunk(List<int> _prob_ref, int _max_prob) {
            _map = new int[_ChunkX, _ChunkY];
            _view = new List<GameObject>();
            for (int x = 0; x < _ChunkX; ++ x) {
                for (int y = 0; y < _ChunkY; ++ y) {
                    int r = Random.Range(0, _max_prob);
                    int id = _prob_ref.BinarySearch(r);
                    if (id < 0) {
                        id = -id - 2;
                    }
                    _map[x, y] = id;
                }
            }
            int k = 7;
            for (int i = 0; i < _ChunkX; ++i)
            {
                _map[i, 0] = k - 1;
                _map[i, _ChunkY - 1] = k - 1;
            }
            for (int i = 0; i < _ChunkY; ++i)
            {
                _map[0, i] = k;
                _map[_ChunkX - 1, i] = k;
            }
            _map[_ChunkX - 1, 0] = k  + 1; // true
            _map[_ChunkX - 1, _ChunkY - 1] = k  + 2;
            _map[0, _ChunkY - 1] = k  + 3;
            _map[0, 0] = k  + 4;

            bool are_far_away = false;
            while(!are_far_away)
            {
                fx =  Random.Range(5, _ChunkX - 4);
                fy =  Random.Range(5, _ChunkY - 4);
                sx =  Random.Range(5, _ChunkX - 4);
                sy =  Random.Range(5, _ChunkY - 4);
                if(fx - sx > _ChunkX / 4 && fy - sy > _ChunkY / 4)
                {
                    are_far_away = true;
                }
            }
            _map[fx, fy] = 4;
            _map[sx, sy] = 4;
        }

        public void draw(Transform transform, Vector3 pos, List<CellRef> RefObjs) {
            for (uint x = 0; x < _ChunkX; ++ x) {
                for (uint y = 0; y < _ChunkY; ++ y) {
                    int id = _map[x, y];
                    float scale = 1.0f / RefObjs[id].sizeRect;
                    Vector3 local_pos = transform.rotation * (new Vector3(x, 0, y) + pos + RefObjs[id].shift * scale) + transform.position;
                    GameObject body = RefObjs[id].gameObjectj;
                    GameObject newObj = Instantiate(body, local_pos, transform.rotation, transform);
                    newObj.transform.localScale = new Vector3(scale, scale, scale);
                    _view.Add(newObj);
                }
            }
            int fid = 12;
            float fscale = 1.0f / RefObjs[fid].sizeRect;
            Vector3 flocal_pos = transform.rotation * (new Vector3(fx, 0, fy) + pos + RefObjs[fid].shift * fscale) + transform.position;
            GameObject fbody = RefObjs[fid].gameObjectj;
            GameObject fnewObj = Instantiate(fbody, flocal_pos, transform.rotation, transform);
            fnewObj.transform.localScale = new Vector3(fscale, fscale, fscale);
            _view.Add(fnewObj);
            int sid = 12;
            float sscale = 1.0f / RefObjs[sid].sizeRect;
            Vector3 slocal_pos = transform.rotation * (new Vector3(sx, 0, sy) + pos + RefObjs[sid].shift * sscale) + transform.position;
            GameObject sbody = RefObjs[sid].gameObjectj;
            GameObject snewObj = Instantiate(sbody, slocal_pos, transform.rotation, transform);
            snewObj.transform.localScale = new Vector3(sscale, sscale, sscale);
            _view.Add(snewObj);
        }   
    }

    private List<Chunk> _world; 
    private List<int> _prob_ref;
    private int _max_prob;


    void Start() {
        _prob_ref = new List<int>(RefObjs.Count + 1);
        
        _prob_ref.Add(0);
        for (int i = 0; i < RefObjs.Count; ++ i) {
            _prob_ref.Add(_prob_ref[i] + RefObjs[i].spwfr);
        }
        _max_prob = _prob_ref[_prob_ref.Count - 1];

        _world = new List< Chunk>();
        Chunk chunk = new Chunk(_prob_ref, _max_prob);
        chunk.draw(transform, new Vector3(0, 0, 0), RefObjs);
        _world.Add(chunk);
        
    }

    void Update() {
    }
}
