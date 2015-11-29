using System;
using System.Collections.Generic;

namespace Helper.Paging.Models
{
    public class IndexViewModel
    {
        public List<ListModel> List { get; set; }

        public int TotalCount { get; set; }

        public int ListPageCount { get; set; }

        public int ActivePageIndex { get; set; }
    }

    public class ListModel
    {
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public string City { get; set; }

        public int Vote { get; set; }
    }
}