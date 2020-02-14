using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CreateTreesFromAddressable : MonoBehaviour
{
    bool treesGenerated;
    void Start()
    {
        treesGenerated = false;
    }

    void FixedUpdate()
    {
        if (!treesGenerated)
        {
            // 通过Addressable Asset生成松树
            // 这个参数自己改，要生成什么，就把参数改成Addressable勾选框后面的那个字符串
            Addressables.InstantiateAsync("fiveTreesPrefab").Completed += OnLoadTreeDone;
            treesGenerated = true;
        }
    }

    void OnLoadTreeDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        try
        {
            GameObject createdObj = obj.Result;
            createdObj.transform.position = transform.position;
            createdObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        catch(UnityException e)
        {
            Debug.Log(e);
        }
    }
}
