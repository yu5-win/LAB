using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tu_BlockSpawn : MonoBehaviour
{
    public Transform Tutorial_blockPrefab;
    public GameObject Block_Spawn;
    public void Spawn_Block()
    {
        Transform Tutorial_block = Instantiate(Tutorial_blockPrefab, Block_Spawn.transform.position, Block_Spawn.transform.rotation);
    }


}
