using System;
using ResourceManager;
using UnityEngine;

namespace ResourceManagement
{
    public interface IResourceManager: IDisposable
    {
        string GetConfig(string path);
        GameObject Instantiate(Transform root, string resource);
        Sprite GetQuestionSprite(int index);
    }

    public class ResourceManager : IResourceManager
    {
        public void Dispose()
        {
        }

        public string GetConfig(string path)
        {
            return Resources.Load<TextAsset>(path).text;
        }
        
        public GameObject Instantiate(Transform root, string resource)
        {
            GameObject goResource = Resources.Load<GameObject>(resource);
            return GameObject.Instantiate(goResource, root);
        }

        public Sprite GetQuestionSprite(int index)
        {
            return Resources.Load<Sprite>($"{ResourceNames.QuestionImagesPath}{index}");
        }
    }
}