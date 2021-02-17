def merge_sorted(head1, head2):
    head = None
    prev = None

    while head1 is not None or head2 is not None:
        if head1 is None and head2 is not None:
            prev.next = head2
            prev = prev.next
            head2 = head2.next
        elif head2 is None and head1 is not None:
            prev.next = head1
            prev = prev.next
            head1 = head1.next
        else:
            if (head1.data > head2.data):
                node = LinkedListNode(head2.data)
                head2 = head2.next
            else:
                node = LinkedListNode(head1.data)
                head1 = head1.next

            if prev is not None:
                prev.next = node
            else:
                head = node

            prev = node

    return head
