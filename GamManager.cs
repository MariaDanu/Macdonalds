 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GamManager : MonoBehaviour
{
    [SerializeField] private List<Bun_pSlot> _slotPrefabs;
    [SerializeField] private Bun_p _bunp;
    [SerializeField] private Transform _slotParent, _bunParent;

  // Start is called before the first frame update
  void Start()
    {
        Spawn();
    }

  void Spawn()
    {
        var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(3).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            //var slot = randomSet[i];
            var spawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity);

            var spawnBunP = Instantiate(_bunp, _bunParent.GetChild(i).position, Quaternion.identity);
            spawnBunP.Init(spawnedSlot);
        }
    }

}
