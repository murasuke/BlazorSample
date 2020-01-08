using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace TextBoxApp4.Data
{
    /// <summary>
    /// ユーザ更新サービス
    /// </summary>
    public class UserDataService
    {
        // DbContext being injected by DI
        LocalDbContext _Context { get; }

        public UserDataService(LocalDbContext context) =>
            _Context = context;

        /// <summary>
        /// ユーザテーブル全体を取得
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetUsersAsync() =>
            _Context.User
                .OrderBy(x => x.Id)
                .ToListAsync();

        /// <summary>
        /// id指定でユーザを検索
        /// </summary>
        /// <returns></returns>
        public User GetUserById(int id) =>        
              _Context.User.Find(id);
        
        /// <summary>
        /// id指定でユーザを検索
        /// </summary>
        /// <returns></returns>
        public ValueTask<User> GetUserByIdAsync(int id) =>
              _Context.User.FindAsync(id);

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <returns></returns>
        public async Task<User> Update(User user)
        {
            _Context.Attach(user).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// 登録処理
        /// </summary>
        /// <returns></returns>
        public async Task<User> Insert(User user)
        {
            _Context.User.Add(user);
            await _Context.SaveChangesAsync();
            user.Insert = false;
            return user;
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <returns></returns>
        public async Task<int> Delete(int id)
        {
            User user = await _Context.User.FindAsync(id);
            _Context.User.Remove(user);
            return await _Context.SaveChangesAsync();
        }

    }

}
