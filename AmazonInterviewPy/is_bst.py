def is_bst_rec(root, min_value, max_value):
    if root == None:
        return True

    if root.data < min_value or root.data > max_value:
        return False

return is_bst_rec(root.left, min_value, root.data) and is_bst_rec(root.right, root.data, max_value)

def is_bst(root):
    return is_bst_rec(root, -sys.maxsize - 1, sys.maxsize)
