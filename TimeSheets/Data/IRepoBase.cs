using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.Data
{
	/// <summary>Базовый интерфейс репозитория</summary>
	/// <typeparam name="T">Тип моделей для хранения</typeparam>
	public interface IRepoBase<T>
	{
		/// <summary>Извлечение элемента из хранилища</summary>
		/// <param name="id">Id элемента</param>
		/// <returns>Искомый элемент</returns>
		Task<T> GetItem(Guid id);

		/// <summary>Извлечение нескольких элементов из хранилища</summary>
		/// <returns>Перечисление содержащее искомые элементы</returns>
		Task<IEnumerable<T>> GetItems();

		/// <summary>Добавление элемента в хранилище</summary>
		/// <param name="item">Модель элемента</param>
		Task Add(T item);

		/// <summary>Обновление элемента в хранилище</summary>
		/// <param name="item">Модель элемента</param>
		Task Update(T item);

		/// <summary>Удаление элемента из хранилища</summary>
		/// <param name="id">Id проверяемого элемента</param>
		Task Delete(Guid id);

		/// <summary>Проверяет помечен ли элемент как удаленный в хранилище</summary>
		/// <param name="id">Id проверяемого элемента</param>
		/// <returns>True - если элемент помечен как удаленный</returns>
		Task<bool> CheckItemIsDeleted(Guid id);
	}
}
