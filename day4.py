
class Board:
    def __init__(self, board):
        self.board = board
        self.marks = [[False for _ in range(5)] for _ in range(5)]
        self.last_draw = None

    def register_draw(self, draw):
        self.last_draw = draw
        for i, board_line in enumerate(self.board):
            for j, spot in enumerate(board_line):
                if spot == draw:
                    self.marks[i][j] = True

    def won(self):
        for row in self.marks:
            if all(row):
                return True
        for column in [[x[n] for x in self.marks] for n in range(5)]:  # transpose
            if all(column):
                return True
        return False

    def score(self):
        "sum of all unmarked numbers * last number drawn"
        unmarked = 0
        for i, board_line in enumerate(self.board):
            for j, x in enumerate(board_line):
                if not self.marks[i][j]:
                    unmarked += int(x)
        return unmarked * int(self.last_draw)


def main():
    draws = []
    boards = []
    input_lines = [line.strip() for line in open("input/day4.txt")]
    draws = input_lines[0].split(',')
    board = []
    for line in input_lines[2:]:
        if line == '':
            boards.append(board)
            board = []
        else:
            board.append(line.split())

    boards = [Board(b) for b in boards]
    first_win = False
    board_won = [False] * len(boards)
    for draw in draws:
        for i, b in enumerate(boards):
            b.register_draw(draw)
            if b.won():
                board_won[i] = True
                if not first_win:
                    print(f"Part 1: {b.score()}")
                    first_win = True
                if all(board_won):
                    print(f"Part 2: {b.score()}")
                    return



if __name__ == '__main__':
    main()
