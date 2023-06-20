using AloKaza.Core.Entities;
using AloKaza.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AloKaza.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new() // Irepository imzası; Class parametresi olmalı, belirlediğimiz IEntity mirasını almalı, newlenebilir olmalı...
    {

        internal DatabaseContext _context; // boş bir database context oluşturuldu

        internal DbSet<T> _dbSet;// Boş bir dbSet tanımladık. Repository'e gönderilecek T class'ını parametre olarak verdik.

        public Repository(DatabaseContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> FindAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
           return _dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList(); // Eğer sadece listeleme yapacaksak, yani liste üzerinde kayıt güncelleme, vb. gibi veri değişikliği yapmayacaksak, AsNoTracking, veri-data iz sürüşünü kaldırır ve performanslı bir şekilde döndürür.
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking().Where(expression).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public int Save()
        {
            return _context.SaveChanges();

            // entity framework de SaveChanges(ekle, güncelle, sil vb işlemleri db ye işleyen metot) metodu direk context üzerinden çalışır, dbset in böyle bir metodu olmadığı için _context.SaveChanges() diyerek database context imiz üzerindeki tüm işlemleri(ekleme, güncelleme, silme vb) veritabanına yansıtmamızı sağlayan bu metodu 1 kere çağırmamız gerekli yoksa işlemler db ye işlenmez!!
        }

        public Task<int> SaveAsync()
        {
           return _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
             _dbSet.Update(entity);
        }
    }
}
