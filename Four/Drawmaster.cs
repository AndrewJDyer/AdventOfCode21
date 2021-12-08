namespace Four
{
    internal class Drawmaster
    {
        private readonly DrawSequence drawSequence;
        private readonly IReadOnlyList<Board> boards;

        public int WinningScore { get; private set; }
        public int LosingScore { get; private set; }

        public Drawmaster(DrawSequence drawSequence, IEnumerable<Board> boards)
        {
            this.drawSequence = drawSequence;
            this.boards = boards.ToList();
        }

        public void RunGame()
        {
            Board losingBoard = null;
            foreach (var drawnNumber in drawSequence)
            {
                RegisterDraw(drawnNumber);
                if (HaveAnyBoardsWon(out var winningScore))
                {
                    WinningScore = winningScore;
                }
                if (losingBoard is null)
                {
                    losingBoard = TryGetLosingBoard();
                }
                else if (losingBoard.Score != null && losingBoard.Score != 0)
                {
                    LosingScore = losingBoard.Score;
                    return;
                }
            }
        }

        private void RegisterDraw(int drawnNumber)
        {
            foreach (var board in boards)
                board.RegisterDraw(drawnNumber);
        }

        private bool HaveAnyBoardsWon(out int winningScore)
        {
            foreach (var board in boards)
            {
                if (board.HaveWon)
                {
                    winningScore = board.Score;
                    return true;
                }
            }

            winningScore = 0;
            return false;
        }

        private Board TryGetLosingBoard()
        {
            var boardsWhichHaveNotWon = boards.Where(b => !b.HaveWon);
            return (boardsWhichHaveNotWon.Count() == 1) ? boardsWhichHaveNotWon.Single() : null;
        }
    }
}
