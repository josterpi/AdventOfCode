
def split(lst, front=True):
    mid = len(lst) // 2
    if front:
        return lst[:mid]
    return lst[mid:]

def seat_id(input):
    row_part, seat_part = input[:7], input[7:]
    rows = range(128)
    for char in row_part:
        rows = split(rows, char == 'F')
    seats = range(8)
    for char in seat_part:
        seats = split(seats, char == 'L')
    return rows[0] * 8 + seats[0]

def main():
    high_seat = 0
    seats = []
    for line in open("day5.txt"):
        id = seat_id(line.strip())
        seats.append(id)
        if id > high_seat:
            high_seat = id
    print(f"Part 1: {high_seat}")
    missing = set(range(high_seat+1)) - set(seats)
    for seat in missing:
        if seat - 1 not in missing and seat + 1 not in missing:
            print(f"Part 2: {seat}")
            return

if __name__ == '__main__':
    main()
