document.addEventListener("DOMContentLoaded", fetchTasks);

function fetchTasks() {
    fetch("/tasks")
        .then(response => response.json())
        .then(tasks => {
            const taskList = document.getElementById("taskList");
            taskList.innerHTML = "";
            tasks.forEach(task => {
                const li = document.createElement("li");
                li.classList.add("task-item");
                
                // ✅ Add a checkbox input element and strike-through functionality
                li.innerHTML = `
                    <div class="task-container">
                        <input type="checkbox" ${task.completed ? 'checked' : ''} onclick="toggleTask(${task.id}, this.checked)">
                        <span class="task-title ${task.completed ? 'completed' : ''}">${task.title}</span>
                        <button class="delete-btn" onclick="deleteTask(${task.id})">X</button>
                    </div>
                `;
                
                taskList.appendChild(li);
            });
        });
}

function addTask() {
    const taskInput = document.getElementById("taskInput");
    const title = taskInput.value.trim();
    if (title === "") return;

    fetch("/tasks/add", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ title: title })
    })
    .then(response => response.json())
    .then(() => {
        taskInput.value = "";
        fetchTasks();
    });
}

function toggleTask(id, completed) {
    fetch(`/tasks/update/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ completed: completed })
    })
    .then(() => fetchTasks());
}

function deleteTask(id) {
    fetch(`/tasks/delete/${id}`, {
        method: "DELETE"
    })
    .then(() => fetchTasks());
}
