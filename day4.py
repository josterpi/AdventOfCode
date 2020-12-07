
import re

def valid_range(s, low, high):
    try:
        i = int(s)
    except ValueError:
        return False
    if low <= i <= high:
        return True
    return False

def valid_height(s):
    units = s[-2:]
    if units not in ('in', 'cm'):
        return False
    try:
        i = int(s[:-2])
    except ValueError:
        return False
    if units == 'cm' and 150 <= i <= 193:
        return True
    if units == 'in' and 59 <= i <= 76:
        return True
    return False

def valid_regex(s, pattern):
    if re.match(pattern, s) is not None:
        return True
    return False

def validator(pp):
    required_fields = ('byr', 'iyr', 'eyr', 'hgt', 'hcl', 'ecl', 'pid')
    if not all([f in pp.keys() for f in required_fields]):
        return False
    if not valid_range(pp['byr'], 1920, 2002):
        return False
    if not valid_range(pp['iyr'], 2010, 2020):
        return False
    if not valid_range(pp['eyr'], 2020, 2030):
        return False
    if not valid_height(pp['hgt']):
       return False
    if pp['ecl'] not in ('amb', 'blu', 'brn', 'gry', 'grn', 'hzl', 'oth'):
        return False
    if not valid_regex(pp['hcl'], '^#[0-9a-f]{6}$'):
        return False
    if not valid_regex(pp['pid'], '^[0-9]{9}$'):
        return False
    return True

def main():
    with open("day4.txt") as f:
        input = [x.split() for x in f.read().split("\n\n")]
    input = [{x.split(':')[0]: x.split(':')[1] for x in y} for y in input]
    required_fields = ('byr', 'iyr', 'eyr', 'hgt', 'hcl', 'ecl', 'pid')
    # cid isn't actually required
    valid = 0
    valid2 = 0
    for pp in input:
        if all([f in pp.keys() for f in required_fields]):
            valid += 1
        if validator(pp):
            valid2 += 1
    print(f"Part 1: {valid}")
    print(f"Part 2: {valid2}")


if __name__ == '__main__':
    main()
