using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Отвечает за действия над фигурами
    /// </summary>
    public class ActionsWithShapes
    {
        public static void ClearShapes(History history, HistoryData historyData)
        {
            for (int i = historyData.Shapes.Count - 1; i > -1; i--)
            {
                history.AddHistory(new CommandShape(historyData.Shapes[i], "Удаление"), false);
            }

            historyData.Shapes = new List<Shape>();
        }
    }
}
