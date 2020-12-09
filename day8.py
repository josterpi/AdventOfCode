
NOP, ACC, JMP = ('nop', 'acc', 'jmp')

test_input = """nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6"""

def parse_input(input):
    parsed = []
    for line in input:
        instr, arg = line.split()
        number = int(arg[1:])
        if arg[0] == '-':
            number = -number
        parsed.append((instr, number))
    return parsed

def run(input):
    accumulator = 0
    pointer = 0
    run_count = [0] * len(input)
    # import pdb; pdb.set_trace()
    while True:
        if run_count[pointer] == 1 or pointer == len(input):
            break
        instr, arg = input[pointer]
        run_count[pointer] += 1
        if instr == NOP:
            pointer += 1
        if instr == ACC:
            accumulator += arg
            pointer += 1
        if instr == JMP:
            pointer += arg
    return accumulator

def main():
    input = [line.strip() for line in open("day8.txt")]
    # input = test_input.split('\n')
    input = parse_input(input)
    accumulator = run(input)
    print(f"Part 1: {accumulator}")

if __name__ == '__main__':
    main()
