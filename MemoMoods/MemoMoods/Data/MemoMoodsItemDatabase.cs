using MemoMoods.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMoods.Data
{
    internal class MemoMoodsItemDatabase
    {
        private readonly SQLiteAsyncConnection _database;
        public MemoMoodsItemDatabase(String dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<MemoMoodsItem>();
        }
        public Task<List<MemoMoodsItem>> GetItemsAsync()
        {
            return _database.Table<MemoMoodsItem>().ToListAsync();
        }
        public Task<List<MemoMoodsItem>> GetItemsNotDoneAsync()
        {
            return _database.QueryAsync<MemoMoodsItem>("SELECT * FROM [MemoMoodsItem] WHERE [Done] =0");
        }
        public Task<MemoMoodsItem> GetItemAsync(int id)
        {
            return _database.Table<MemoMoodsItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(MemoMoodsItem item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(MemoMoodsItem item)
        {
            return _database.DeleteAsync(item);
        } 
    }
}
