using MongoDB.Bson;
using Survey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class Question:MongoBaseModel
    {
        /// <summary>
        /// 排序Id
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 问卷调查Id
        /// </summary>
        public string SurveryId { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 题目类型    
        /// </summary>
        public QuestionType QuestionType { get; set; }
        /// <summary>
        /// 选项
        /// </summary>
        public IEnumerable<Selection> Selections { get; set; }
        /// <summary>
        /// 表单名称
        /// </summary>
        public string FormName { get; set; }
    }

    public enum QuestionType
    {
        /// <summary>
        /// 单选  
        /// </summary>
        SingleSelection = 1,
        /// <summary>
        /// 多选
        /// </summary>
        MultipleSelection = 2,
        /// <summary>
        /// 问答形式
        /// </summary>
        QandA = 4
    }

    public class Selection
    {
        public string Context { get; set; }
        public string Value { get; set; }
    }
}
