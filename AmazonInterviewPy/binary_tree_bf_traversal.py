def level_order_traversal(root):
    if root == None:
        return

    result = ""
    queues = [deque(), deque()]
    current_queue = queues[0]
    next_queue = queues[1]  
    level_number = 0
    
    current_queue.append(root)
    
    while current_queue:
        temp = current_queue.popleft()
        result += str(temp.data) + " "

        if temp.left != None:
            next_queue.append(temp.left)

        if temp.right != None:
            next_queue.append(temp.right)

        if not current_queue:
            level_number += 1
            current_queue = queues[level_number % 2]
            next_queue = queues[(level_number + 1) % 2]

    return result
   