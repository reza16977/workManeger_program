using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Model
{
    class WorkList
    {
        private ObservableCollection<Work> works;

        public WorkList()
        {
            works = new ObservableCollection<Work>();

            works.Add(new Work() { Title = "요구사항 정리",   StartDate = "20230120", EndDate = "20230320", Manager = "홍길동", ProgressRate = 100, Description = "고객으로부터의 요구사항을 정리" });
            works.Add(new Work() { Title = "설계",            StartDate = "20230210", EndDate = "20230417", Manager = "제임스", ProgressRate = 80, Description = "소프트웨어의 전체적인 골격 설계" });
            works.Add(new Work() { Title = "기능 구현",       StartDate = "20230220", EndDate = "20230620", Manager = "아이브", ProgressRate = 50, Description = "요구사항에 맞게 설계대로 구현" });
            works.Add(new Work() { Title = "설계 문서 작성",  StartDate = "20230320", EndDate = "20230530", Manager = "아이유", ProgressRate = 20, Description = "설계된 내용을 문서에 정리" });
            works.Add(new Work() { Title = "테스트",          StartDate = "20230701", EndDate = "20230730", Manager = "아이브", ProgressRate = 0, Description = "테스트 케이스에 따라 기능 검증" });
        }

        public ObservableCollection<Work> GetWorkList()
        {
            return works;
        }
    }
}
