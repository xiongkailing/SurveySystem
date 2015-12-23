using MongoDB.Bson;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Survery.Website.Areas.Manage.Models
{
    public class QuestionViewModel
    {
        public string Id { get; set; }
        [Display(Name = "排序")]
        /// <summary>
        /// 排序Id
        /// </summary>
        public int SortId { get; set; }
        [Display(Name = "问卷Id")]
        /// <summary>
        /// 问卷调查Id
        /// </summary>
        public string SurveryId { get; set; }
        [Display(Name = "问题描述")]
        /// <summary>
        /// 问题描述
        /// </summary>
        public string Description { get; set; }
        [Display(Name = "题目类型")]
        /// <summary>
        /// 题目类型    
        /// </summary>
        public QuestionType QuestionType { get; set; }
        [Display(Name = "选项")]
        /// <summary>
        /// 选项
        /// </summary>
        public IEnumerable<Selection> Selections { get; set; }
        /// <summary>
        /// 表单名称
        /// </summary>
        public string FormName { get; set; }
        public void MapFromEntity(Question entity)
        {
            this.Id = entity._id.ToString();
            this.Description = entity.Description;
            this.SortId = entity.SortId;
            this.SurveryId = entity.SurveryId;
            this.Selections = entity.Selections;
            this.QuestionType = entity.QuestionType;
            this.FormName = entity.FormName;
        }
        public Question MapToEntity()
        {
            Question question = new Question();
            ObjectId _id = ObjectId.GenerateNewId();
            if (!string.IsNullOrEmpty(this.Id))
            {
                if (!ObjectId.TryParse(this.Id, out _id))
                {
                    throw new ArgumentOutOfRangeException("id exception");
                }
            }
            question._id = _id;
            question.Description = this.Description;
            question.SortId = this.SortId;
            question.SurveryId = this.SurveryId;
            question.Selections = this.Selections;
            question.QuestionType = this.QuestionType;
            question.FormName = this.FormName;
            return question;
        }
    }
}