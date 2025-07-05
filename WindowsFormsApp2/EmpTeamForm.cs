INCLUDE Irvine32.inc

.data
    ; Game grid: 10x20(width x height), 0 = empty, 1 = block
    grid BYTE 200 DUP(0)        ; 10x20 grid
    blockX DWORD 4              ; Block's top-left x position
    blockY DWORD 0              ; Block's top-left y position
    gameWidth DWORD 10          ; Grid width
    gameHeight DWORD 20         ; Grid height
    prompt BYTE "Use A/D to move left/right, S to move down, Q to quit", 0
    blockChar BYTE '@'          ; Character for block
    emptyChar BYTE '.'          ; Character for empty space
    newline BYTE 0Dh, 0Ah, 0    ; Carriage return + line feed

.code
main PROC
    ; Initialize console
    call Clrscr
    mov edx, OFFSET prompt
    call WriteString
    call Crlf

gameLoop:
    ; Clear grid
    mov ecx, 200
    mov edi, OFFSET grid
    mov al, 0
    rep stosb

    ; Place block(2x2 square)
    mov eax, blockY
    mov ebx, gameWidth
    mul ebx
    add eax, blockX
    mov edi, OFFSET grid
    add edi, eax
    mov BYTE PTR [edi], 1; Top - left
    mov BYTE PTR [edi+1], 1; Top - right
    mov BYTE PTR [edi+10], 1; Bottom - left(using literal 10 instead of gameWidth)
    mov BYTE PTR [edi+11], 1; Bottom - right

    ; Display grid
    call DisplayGrid

    ; Check for user input
    call ReadKey
    jz noInput                          ; No key pressed
    cmp al, 'q'
    je exitGame                         ; Quit on 'q'
    cmp al, 'a'
    je moveLeft
    cmp al, 'd'
    je moveRight
    cmp al, 's'
    je moveDown
    jmp noInput

moveLeft:
    cmp blockX, 0
    je noInput                          ; Can't move left if at edge
    dec blockX
    jmp noInput

moveRight:
    mov eax, blockX
    add eax, 2                          ; Block width
    cmp eax, gameWidth
    jae noInput                         ; Can't move right if at edge
    inc blockX
    jmp noInput

moveDown:
    mov eax, blockY
    add eax, 2                          ; Block height
    cmp eax, gameHeight
    jae exitGame                        ; Stop if block hits bottom
    inc blockY
    jmp noInput

noInput:
    ; Simple delay to slow down game
    mov eax, 100
    call Delay

    ; Auto - move block down
    mov eax, blockY
    add eax, 2
    cmp eax, gameHeight
    jae exitGame
    inc blockY

    ; Clear screen for next frame
    call Clrscr
    mov edx, OFFSET prompt
    call WriteString
    call Crlf
    
    jmp gameLoop

exitGame:
    call Clrscr
    mov edx, OFFSET prompt
    call WriteString
    call Crlf
    call WaitMsg
    exit
main ENDP

DisplayGrid PROC
    pushad
    mov esi, OFFSET grid
    mov ecx, gameHeight
displayRow:
    push ecx; Save outer loop counter
    mov ecx, gameWidth
displayCol:
    mov al, [esi]
    cmp al, 1
    je printBlock
    mov al, emptyChar
    jmp printChar
printBlock:
    mov al, blockChar
printChar:
    call WriteChar
    inc esi
    loop displayCol
    
    mov edx, OFFSET newline
    call WriteString
    pop ecx         ; Restore outer loop counter
    loop displayRow
    popad
    ret
DisplayGrid ENDP

END main