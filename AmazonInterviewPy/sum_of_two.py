find_sum_of_two([2, 1, 8, 4, 7, 3],3)

def find_sum_of_two(A, val):
    pairs = dict()

    for cnt in range(0, len(A)):
        if (A[cnt] in pairs):
            return True

        the_other_number = val - A[cnt]
        pairs[the_other_number] = A[cnt]

    return False
