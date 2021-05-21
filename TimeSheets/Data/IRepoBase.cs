using System;
using System.Collections.Generic;

namespace TimeSheets.Data
{
	/// <summary>Базовый интерфейс репозитория</summary>
	/// <typeparam name="T">Тип моделей для хранения</typeparam>
	public interface IRepoBase<T>
	{
		/// <summary>Извлечение элемента из хранилища</summary>
		/// <param name="id">Id элемента</param>
		/// <returns>Искомый элемент</returns>
		T GetItem(Guid id);

		/// <summary>Извлечение нескольких элементов из хранилища</summary>
		/// <returns>Перечисление содержащее искомые элементы</returns>
		IEnumerable<T> GetItems();

		/// <summary>Добавление элемента в хранилище</summary>
		/// <param name="item">Модель элемента</param>
		void Add(T item);

		/// <summary>Обновление элемента в хранилище</summary>
		void Update();
	}
}
