
import re

def count_letter(char, hay):
    return len(hay) - len(hay.replace(char, ''))

def main():
    good = 0
    for line in open("day2.txt"):
        low, high, char, pwd = re.match(r"(\d+)-(\d+) ([a-z]): ([a-z]+)", line.strip()).groups()
        count = count_letter(char, pwd)
        if int(low) <= count and count <= int(high):
            good += 1
    print(f"Part 1: {good}")

if __name__ == '__main__':
    main()
