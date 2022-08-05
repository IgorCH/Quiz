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
    public enum Category: short
    {
        culture = 0,
        earth = 1,
        history = 2,
        nature = 3,
        sport = 4
    }
    
    [Serializable]
    public class Question
    {
        public int id;
        public int prevId;
        public string title;
        public Category category;
        public List<Answer> answers;
    }

    public interface IDataSource : IDisposable
    {
        List<Question> Questions { get; }
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

        public List<Question> Questions => _questions;

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