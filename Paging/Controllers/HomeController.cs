using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Paging.Models;

namespace Paging.Controllers
{
    public class HomeController : Controller
    {
        private readonly int _listPageCount = int.Parse(ConfigurationManager.AppSettings.Get("ListPageCount"));

        public ActionResult Index(string page)
        {
            int totalCount;
            int temp;
            int index = int.TryParse(page, out temp) ? temp : 1;
            var model = new IndexViewModel
            {
                List = GetList(index, out totalCount),
                TotalCount = totalCount,
                ListPageCount = _listPageCount,
                ActivePageIndex = index
            };
            return View(model);
        }

        private List<ListModel> GetList(int index, out int totalCount)
        {
            var list = new List<ListModel>
            {
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 1", City = "Sinop", Vote = 1},
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 2", City = "Manisa", Vote = 2},
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 3", City = "Samsun", Vote = 4},
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 4", City = "İstanbul", Vote = 7},
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 5", City = "Ankara", Vote = 18},
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 6", City = "Sinop", Vote = 1},
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 7", City = "Manisa", Vote = 2},
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 8", City = "Samsun", Vote = 4},
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 9", City = "İstanbul", Vote = 7},
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 10", City = "Ankara", Vote = 18},
                new ListModel {CreateDate = DateTime.Now, Name = "Liste 11", City = "Ankara", Vote = 18}
            };

            totalCount = list.Count;
            return list.Take(index * _listPageCount).Skip((index - 1) * _listPageCount).ToList();
        }
	}
}
