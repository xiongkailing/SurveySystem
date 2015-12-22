using MongoDB.Bson;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Survery.Website.Areas.Manage.Models
{
    public class SurveyTitleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "调查名称")]
        /// <summary>
        /// 调查名称   
        /// </summary>
        public string Name { get; set; }
        [Display(Name="创建时间")]
        /// <summary>
        /// 创建时间   
        /// </summary>
        public DateTime CreateTime { get; set; }
        [Display(Name = "截至时间")]
        /// <summary>
        /// 截至时间   
        /// </summary>
        public DateTime DeadLine { get; set; }
        [Display(Name = "适用人群")]
        /// <summary>
        /// 适合人群描述
        /// </summary>
        public string Fitter { get; set; }
        /// <summary>
        /// 推送用户Ids
        /// </summary>
        public IEnumerable<int> UserIds { get; set; }

        public void MapFromEntity(SurveyTitle entity)
        {
            this.Id = entity._id.ToString();
            this.Fitter = entity.Fitter;
            this.CreateTime = entity.CreateTime;
            this.DeadLine = entity.DeadLine;
            this.Name = entity.Name;
        }
        public SurveyTitle MapToEntity()
        {
            SurveyTitle st = new SurveyTitle();
            ObjectId _id=ObjectId.GenerateNewId();
            if (!string.IsNullOrEmpty(this.Id))
            {
                if (!ObjectId.TryParse(this.Id, out _id))
                {
                    throw new ArgumentOutOfRangeException("id exception");
                }
            }
            st._id = _id;
            st.CreateTime =this. CreateTime;
            st.DeadLine =this. DeadLine;
            st.Fitter = this.Fitter;
            st.Name = this.Name;
            return st;
        }
    }
}