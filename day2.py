
import re

def count_letter(char, hay):
    return len(hay) - len(hay.replace(char, ''))

def main():
    good = 0
    good2 = 0
    for line in open("input/day2.txt"):
        low, high, char, pwd = re.match(r"(\d+)-(\d+) ([a-z]): ([a-z]+)", line.strip()).groups()
        count = count_letter(char, pwd)
        if int(low) <= count and count <= int(high):
            good += 1
        # bool(a) ^ bool(b) is XOR
        if bool(pwd[int(low)-1] == char) ^ bool(pwd[int(high)-1] == char):
            good2 += 1
    print(f"Part 1: {good}")
    print(f"Part 2: {good2}")

if __name__ == '__main__':
    main()
