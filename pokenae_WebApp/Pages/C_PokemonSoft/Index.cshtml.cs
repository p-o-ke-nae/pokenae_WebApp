using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using pokenae_WebApp.Data;
using pokenae_WebApp.Models;

namespace pokenae_WebApp.Pages.C_PokemonSoft
{
    public class IndexModel : PageModel
    {
        private readonly pokenae_WebApp.Data.pokenae_WebAppContext _context;

        public IndexModel(pokenae_WebApp.Data.pokenae_WebAppContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public IList<V_C_PokemonSoft> V_C_PokemonSofts { get;set; } = default!;

        //新規作成用
        [BindProperty(SupportsGet = true)]
        public IList<V_C_PokemonSoft> Create_V_C_PokemonSofts { get; set; }
        public SelectList? PokemonSoftList { get; set; }

        //検索用
        /// <summary>
        /// タイトル一覧
        /// </summary>
        public SelectList? Titles { get; set; }
        /// <summary>
        /// 検索：タイトル
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string? SearchTitle { get; set; }

        /// <summary>
        /// 世代一覧
        /// </summary>
        public SelectList? Gens { get; set; }
        /// <summary>
        /// 検索：世代
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? SearchGen { get; set; }

        /// <summary>
        /// 開発元一覧
        /// </summary>
        public SelectList? Developers { get; set; }
        /// <summary>
        /// 検索：開発元
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string? SearchDeveloper { get; set; }

        /// <summary>
        /// ハード一覧
        /// </summary>
        public SelectList? Hards { get; set; }
        /// <summary>
        /// 検索：ハード
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string? SearchHard { get; set; }




        public async Task OnGetAsync()
        {
            await ComboItemLoad();

            var packlist = from s in _context.V_C_PokemonSoft select s;

            V_C_PokemonSofts = SearchList<V_C_PokemonSoft>(packlist).ToList();

            //新規作成の準備
            if (Create_V_C_PokemonSofts == null || Create_V_C_PokemonSofts.Count <= 0)
            {
                CreateTableClear();
            }
        }

        public async Task OnPostAsync(string update,string create)
        {
            await ComboItemLoad();

            if (!string.IsNullOrEmpty(update))
            {
                bool changeFlg = false;
                //更新
                foreach (var item in V_C_PokemonSofts)
                {
                    var model = (from s in _context.C_PokemonSoft where s.ID == item.ID select s).FirstOrDefault();

                    if (model != null)
                    {
                        item.ConvertToModel(model);

                        _context.C_PokemonSoft.Update(model);
                        changeFlg |= true;
                    }

                }

                //新規作成
                var createlist = new List<IV_C_PokemonSoft>();
                var retrylist = new List<V_C_PokemonSoft>();

                while (0 < Create_V_C_PokemonSofts.Count)
                {
                    if (!string.IsNullOrEmpty(Create_V_C_PokemonSofts[0].MPokemonSoftCODE))
                    {
                        createlist.Add(Create_V_C_PokemonSofts[0]);
                    }
                    else
                    {
                        retrylist.Add(Create_V_C_PokemonSofts[0]);
                    }

                    Create_V_C_PokemonSofts.RemoveAt(0);
                }

                //登録
                //IDを生成
                var old = (from s in _context.V_C_PokemonSoft
                           orderby s.ID descending
                           select s).FirstOrDefault();
                int newid = 0;
                if (old != null)
                {
                    var oldid = old.ID.Substring(3, 4);

                    if (int.TryParse(oldid, out newid) == false)
                    { }
                }

                foreach (var item in createlist)
                {
                    newid++;
                    item.ID = V_C_PokemonSoft.IDStr + newid.ToString("0000");

                    //DBに登録
                    var newmodel = new Models.C_PokemonSoft();
                    newmodel.ID = item.ID;
                    item.ConvertToModel(newmodel);

                    _context.C_PokemonSoft.Add(newmodel);
                    changeFlg |= true;
                }

                //登録失敗したものを保持するための処理
                if (retrylist.Count == 0)
                {
                    retrylist.Add(new V_C_PokemonSoft());

                    ModelState.Remove("Create_V_C_PokemonSofts[0].Label");
                    ModelState.Remove("Create_V_C_PokemonSofts[0].MPokemonSoftCODE");
                    ModelState.Remove("Create_V_C_PokemonSofts[0].DLFlg");
                    ModelState.Remove("Create_V_C_PokemonSofts[0].Memo");
                }
                else
                {
                    for (int i = 0; i < retrylist.Count; i++)
                    {
                        ModelState.Remove("Create_V_C_PokemonSofts[0].Label");
                        ModelState.Remove("Create_V_C_PokemonSofts[0].MPokemonSoftCODE");
                        ModelState.Remove("Create_V_C_PokemonSofts[0].DLFlg");
                        ModelState.Remove("Create_V_C_PokemonSofts[0].Memo");
                    }
                }
                
                Create_V_C_PokemonSofts = retrylist;
                

                //DBに反映
                if (changeFlg == true)
                {
                    _context.SaveChanges();
                }
            }
            else if (!string.IsNullOrEmpty(create))
            {
                Create_V_C_PokemonSofts.Add(new V_C_PokemonSoft());
            }

        }

        /// <summary>
        /// 各コンボボックスのアイテムをDBより取得し，格納
        /// </summary>
        /// <returns></returns>
        private async Task ComboItemLoad()
        {
            IQueryable<string> titleQuery = (from m in _context.V_M_PokemonSoft
                                             orderby m.ID
                                             select m.Title);
            IQueryable<double> genQuery = (from m in _context.V_M_PokemonSoft
                                             orderby m.ID
                                             select m.Gen);
            IQueryable<string> developerQuery = from m in _context.V_M_PokemonSoft
                                                orderby m.MDeveloperCODE
                                                select m.DeveloperName;
            IQueryable<string> hardQuery = from m in _context.V_M_PokemonSoft
                                           orderby m.MHardCategoryCODE
                                           select m.HardCategoryName;
            
            var pokemonSoftQuery = from m in _context.V_M_PokemonSoft
                                   orderby m.ID
                                   select new { m.Title, m.ID };

            Titles = new SelectList(await titleQuery.ToListAsync());
            Gens = new SelectList(await genQuery.Distinct().ToListAsync());
            Developers = new SelectList(await developerQuery.Distinct().ToListAsync());
            Hards = new SelectList(await hardQuery.Distinct().ToListAsync());
            
            PokemonSoftList = new SelectList(await pokemonSoftQuery.ToListAsync(), "ID", "Title");

        }

        /// <summary>
        /// 新規登録用テーブルの初期化
        /// </summary>
        private void CreateTableClear()
        {
            if(Create_V_C_PokemonSofts != null)
            {
                Create_V_C_PokemonSofts.Clear();
            }
            else
            {
                Create_V_C_PokemonSofts = new List<V_C_PokemonSoft>();
            }
            
            Create_V_C_PokemonSofts.Add(new V_C_PokemonSoft());

            //1行目を空欄にする処理
            ModelState.Remove("Create_V_C_PokemonSofts[0].Label");
            ModelState.Remove("Create_V_C_PokemonSofts[0].ID");
        }

        /// <summary>
        /// リストを条件より絞り込む
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        private IEnumerable<T> SearchList<T>(IEnumerable<T> list) where T : IV_C_PokemonSoft
        {
            if (!string.IsNullOrEmpty(SearchTitle))
            {
                list = list.Where(s => s.Title.Contains(SearchTitle));
            }
            if (SearchGen != null)
            {
                list = list.Where(s => s.Gen == SearchGen);
            }
            if (!string.IsNullOrEmpty(SearchDeveloper))
            {
                list = list.Where(s => s.DeveloperName.Contains(SearchDeveloper));
            }
            if (!string.IsNullOrEmpty(SearchHard))
            {
                list = list.Where(s => s.HardCategoryName.Contains(SearchHard));
            }

            list = list.OrderBy(s => s.MPokemonSoftCODE).ThenBy(s => s.ID);

            return list;
        }

    }
}
