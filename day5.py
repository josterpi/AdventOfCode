
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
    for line in open("day5.txt"):
        id = seat_id(line.strip())
        if id > high_seat:
            high_seat = id
    print(f"Part 1: {high_seat}")

if __name__ == '__main__':
    main()
