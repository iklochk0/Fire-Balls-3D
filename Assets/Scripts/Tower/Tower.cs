using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    TowerBuilder _towerBuilder;
    List<Block> _blocks;

    public event UnityAction<int> sizeUpdated;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();
        
        foreach (var block in _blocks)
        {
            block.BulletHit += onBulletHit;
        }

        sizeUpdated?.Invoke(_blocks.Count);
    }

    void onBulletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= onBulletHit;

        _blocks.Remove(hitedBlock);

        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }

        sizeUpdated?.Invoke(_blocks.Count);
    }
}
