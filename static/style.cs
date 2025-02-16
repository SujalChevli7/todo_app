/* Reset default styles */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

/* Full-page styling */
body {
    font-family: 'Poppins', sans-serif;
    background: linear-gradient(135deg, #667eea, #764ba2);
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    width: 100vw;
    overflow: hidden;
}

/* Centered container */
.container {
    width: 90%;
    max-width: 600px;
    background: rgba(255, 255, 255, 0.2);
    padding: 40px;
    border-radius: 15px;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
    text-align: center;
    backdrop-filter: blur(10px);
    display: flex;
    flex-direction: column;
    align-items: center;
}

/* Title */
h1 {
    color: white;
    font-size: 30px;
    margin-bottom: 20px;
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 10px;
}

/* Task input section */
.task-input {
    display: flex;
    align-items: center;
    justify-content: space-between;
    background: rgba(255, 255, 255, 0.3);
    padding: 15px;
    width: 100%;
    max-width: 500px;
    border-radius: 30px;
    box-shadow: inset 2px 2px 5px rgba(0, 0, 0, 0.1);
}

.task-input input {
    flex: 1;
    border: none;
    background: none;
    padding: 12px;
    font-size: 16px;
    outline: none;
    color: white;
}

.task-input input::placeholder {
    color: rgba(255, 255, 255, 0.7);
}

/* Add Button */
.task-input button {
    background: #ff4757;
    border: none;
    color: white;
    font-size: 18px;
    padding: 12px;
    border-radius: 50%;
    cursor: pointer;
    transition: transform 0.2s ease-in-out, background 0.3s ease-in-out;
}

.task-input button:hover {
    transform: scale(1.1);
    background: #e63946;
}

/* Task list styling */
ul {
    list-style: none;
    padding: 0;
    margin-top: 20px;
    width: 100%;
    max-width: 500px;
}

/* Each task */
li {
    display: flex;
    align-items: center;
    gap: 10px;
    background: rgba(255, 255, 255, 0.2);
    padding: 14px;
    margin: 10px 0;
    border-radius: 10px;
    box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.1);
    width: 100%;
    transition: transform 0.2s ease-in-out;
}

li:hover {
    transform: scale(1.02);
}

/* Checklist-style checkbox */
.task-checkbox {
    appearance: none;
    width: 20px;
    height: 20px;
    border: 2px solid white;
    border-radius: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
    cursor: pointer;
    transition: background 0.3s ease-in-out, border 0.3s ease-in-out;
}

/* Checked checkbox */
.task-checkbox:checked {
    background: white;
    border: 2px solid #764ba2;
    position: relative;
}

.task-checkbox:checked::after {
    content: "✔";
    color: #764ba2;
    font-size: 14px;
    font-weight: bold;
    position: absolute;
    top: 2px;
    left: 4px;
}

/* Completed task - Strikethrough */
.completed {
    text-decoration: line-through;
    opacity: 0.6;
    transition: opacity 0.3s ease-in-out;
}

/* Task text */
.task-text {
    font-size: 18px;
    flex-grow: 1;
}

/* Delete Button */
.delete-btn {
    background: #ff4757;
    color: white;
    border: none;
    padding: 6px 12px;
    border-radius: 5px;
    cursor: pointer;
    transition: background 0.3s ease-in-out;
}

.delete-btn:hover {
    background: #c82333;
}
