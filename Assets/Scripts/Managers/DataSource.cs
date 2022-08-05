using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ResourceManagement;
using ResourceManager;
using UnityEngine;

namespace Managers
{
    [SerializeField]
    public class Answer
    {
        public string text;
        public bool isRight;
    }

    [Serializable]
    public class Question
    {
        public int id;
        public string title;
        public List<Answer> answers;
    }

    public interface IDataSource : IDisposable
    {
        Question GetQuestion(int index);
    }

    public class DataSource: IDataSource
    {
        public List<Question> _questions;

        public DataSource(IResourceManager resourceManager)
        {
            string data = resourceManager.GetConfig(ResourceNames.Questions);
            _questions = JsonConvert.DeserializeObject<List<Question>>(data);
        }

        public Question GetQuestion(int index)
        {
            if (index < _questions.Count)
            {
                return _questions[index];
            }

            Debug.LogError("Wrong item index!");
            return null;
        }

        public void Dispose()
        {
            _questions.Clear();
        }
    }
}