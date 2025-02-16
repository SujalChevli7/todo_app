document.addEventListener("DOMContentLoaded", fetchTasks);

function fetchTasks() {
    fetch("/tasks")
        .then(response => response.json())
        .then(tasks => {
            const taskList = document.getElementById("taskList");
            taskList.innerHTML = "";
            tasks.forEach(task => {
                const li = document.createElement("li");

                // Checkbox for marking completion
                const checkbox = document.createElement("input");
                checkbox.type = "checkbox";
                checkbox.checked = task.completed;
                checkbox.classList.add("task-checkbox");
                checkbox.onclick = () => toggleTask(task.id, task.completed);

                // Task text
                const taskText = document.createElement("span");
                taskText.textContent = task.title;
                taskText.classList.add("task-text");
                if (task.completed) {
                    taskText.classList.add("completed"); // Apply strikethrough if completed
                }

                // Delete button
                const deleteBtn = document.createElement("button");
                deleteBtn.classList.add("delete-btn");
                deleteBtn.textContent = "❌";
                deleteBtn.onclick = () => deleteTask(task.id);

                li.appendChild(checkbox);
                li.appendChild(taskText);
                li.appendChild(deleteBtn);
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
        body: JSON.stringify({ completed: !completed })
    })
    .then(() => fetchTasks());
}

function deleteTask(id) {
    fetch(`/tasks/delete/${id}`, {
        method: "DELETE"
    })
    .then(() => fetchTasks());
}
