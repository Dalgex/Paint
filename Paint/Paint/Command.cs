using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Объявляет интерфейс для отмены и повторения действий пользователя
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Выполняет команду
        /// </summary>
        public abstract void Execute(HistoryData historyData);

        /// <summary>
        /// Отменяет команду
        /// </summary>
        public abstract void UnExecute(HistoryData historyData);
    }
}
