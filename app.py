from flask import Flask, render_template, request, jsonify
from flask_restful import Api, Resource
import mysql.connector

app = Flask(__name__, template_folder="templates", static_folder="static")
api = Api(app)

# Connect to MySQL
db = mysql.connector.connect(
    host="localhost",
    user="root",
    password="Sujal@8141",
    database="todo_db"
)
cursor = db.cursor(dictionary=True)

@app.route('/')
def home():
    return render_template("index.html")

# API Routes
class GetAllTasks(Resource):
    def get(self):
        cursor.execute("SELECT * FROM tasks")
        tasks = cursor.fetchall()
        return jsonify(tasks)

class AddTask(Resource):
    def post(self):
        data = request.get_json()
        title = data['title']
        cursor.execute("INSERT INTO tasks (title) VALUES (%s)", (title,))
        db.commit()
        return jsonify({"message": "Task added successfully!"})

class UpdateTask(Resource):
    def put(self, task_id):
        data = request.get_json()
        completed = data['completed']
        cursor.execute("UPDATE tasks SET completed = %s WHERE id = %s", (completed, task_id))
        db.commit()
        return jsonify({"message": "Task updated successfully!"})

class DeleteTask(Resource):
    def delete(self, task_id):
        cursor.execute("DELETE FROM tasks WHERE id = %s", (task_id,))
        db.commit()
        return jsonify({"message": "Task deleted successfully!"})

api.add_resource(GetAllTasks, "/tasks")
api.add_resource(AddTask, "/tasks/add")
api.add_resource(UpdateTask, "/tasks/update/<int:task_id>")
api.add_resource(DeleteTask, "/tasks/delete/<int:task_id>")

if __name__ == '__main__':
    app.run(debug=True, port=5001)
