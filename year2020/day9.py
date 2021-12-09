
def find_sum(n, numbers):
    for i, x in enumerate(numbers):
        for j, y in enumerate(numbers):
            if i != j and x + y == n:
                return True
    return False

test = [35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299]

def main():
    input = [int(line.strip()) for line in open("input/day9.txt")]
    for i in range(25, len(input)):
        if not find_sum(input[i], input[i-25:i]):
            print(f"Part 1: {input[i]}")

if __name__ == "__main__":
    main()
