using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Отвечает за историю изменений
    /// </summary>
    public class History
    {       
        private Stack<Command> undo = new Stack<Command>();
        private Stack<Command> redo = new Stack<Command>();

        /// <summary>
        /// Показывает, можно ли отменить действие
        /// </summary>
        private bool CanUndo { get { return undo.Count > 0; } }

        /// <summary>
        /// Показывает, можно ли восстановить отмененное действие
        /// </summary>
        private bool CanRedo { get { return redo.Count > 0; } }

        public bool WasHistoryAction { get; set; }

        /// <summary>
        /// Добавляет в историю команду и логический параметр, показывающий, завершилась команда или нет
        /// </summary>
        public void AddHistory(Command command, bool isCommandOver)
        {
            undo.Push(command);

            if (isCommandOver)
            {
                undo.Push(null);
            }

            ClearRedoHistory();
        }

        /// <summary>
        /// Отменяет последнюю операцию
        /// </summary>
        public void Undo(HistoryData historyData)
        {
            if (CanUndo)
            {
                undo.Pop();
                WasHistoryAction = true;

                while (undo.Count > 0 && undo.Peek() != null)
                {
                    redo.Push(undo.Pop());
                    redo.Peek().UnExecute(historyData);
                }

                redo.Push(null);
            }
        }

        /// <summary>
        /// Повторяет последнее действие, которое было отменено
        /// </summary>
        public void Redo(HistoryData historyData)
        {
            if (CanRedo)
            {
                redo.Pop();
                WasHistoryAction = true;

                while (redo.Count > 0 && redo.Peek() != null)
                {
                    undo.Push(redo.Pop());
                    undo.Peek().Execute(historyData);
                }

                undo.Push(null);
            }
        }

        /// <summary>
        /// Очищает стек Redo
        /// </summary>
        private void ClearRedoHistory()
        {
            if (redo.Count != 0)
            {
                redo = new Stack<Command>();
            }
        }
         
    }
}
