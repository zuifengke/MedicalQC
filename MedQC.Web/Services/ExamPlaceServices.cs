using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedQC.Web.Utility;

namespace MedQC.Web
{
    public class ExamPlaceServices
    {
        

        public static List<Models.ExamPlace> GetExamPlaces()
        {
            if(!Utility.CacheHelper.IsExistCache("ExamPlaces"))
            {
                var result = EnterRepository.GetRepositoryEnter().ExamPlaceRepository.LoadEntities().ToList().ToList();
                CacheHelper.AddCache("ExamPlaces", result, 1);
                return result;
            }
            return CacheHelper.GetCache("ExamPlaces") as List<Models.ExamPlace>;
        }
    }
}