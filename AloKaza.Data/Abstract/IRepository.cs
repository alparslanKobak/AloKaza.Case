using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AloKaza.Data.Abstract
{
    public interface IRepository <T> where T : class // IRepository interface'i dışarıdan alacağı T parametresi ile çalışacak... Where şartı ile de bu bir class olmalıdır koşulu sunuldu...
    {
        List<T> GetAll();  // Database üzerinde bulunan kayıtların, parametre üzerinde verilen class'ın bilgilerinin tamamını çek. NOT: Include edilmemiş şekilde...

        List<T> GetAll(Expression<Func<T,bool>> expression); // Lambda kullanabileceğimiz GetAll Metodu

        T Get(Expression<Func<T, bool>> expression); // Lambda expression ile geriye yalnızca 1 kayıt döndürür.

        T Find(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        int Save(); // return Ok(200)

        // Asenkron Metotlar : Birden çok işlemi aynı anda yüklememizi sağlayan, performans optimizasyonu hedefleyen metodlardır.

        Task<T> FindAsync(int id);

        Task<T> GetAsync(Expression<Func<T,bool>> expression);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> expression);

        Task AddAsync(T entity);

        Task<int> SaveAsync();







    }
}
