using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using intX.Models;
using SQLite;

namespace intX.Data
{
    public class RateDatabase
    {
        readonly SQLiteAsyncConnection database;
        public RateDatabase(string path)
        {

            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Rate>().Wait();
            database.CreateTableAsync<Admin>().Wait();
            database.CreateTableAsync<User>().Wait();
        }
        public Task<List<Rate>> GetItemsAsync()
        {
            return database.Table<Rate>().ToListAsync();
        }
        public Task<List<Rate>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Rate>("SELECT * FROM [RateItem] WHERE [Done] = 0");
        }
        public Task<int> UpdateItems(Rate item)
        {
            return database.UpdateAsync(item);
        }
        public Task<Rate> GetItemAsync(int id)
        {
            return database.Table<Rate>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Rate item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Rate item)
        {
            return database.DeleteAsync(item);
        }


        public Task<List<Admin>> GetAdminAsync()
        {
            return database.Table<Admin>().ToListAsync();
        }
        public Task<int> SaveAdminAsync(Admin item)
        {
            return database.InsertAsync(item);
        }

        public Task<List<User>> GetUserAsync()
        {
            return database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<User> GetUser(int id)
        {
            return database.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }


    }
}
