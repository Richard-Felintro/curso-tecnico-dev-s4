import { useEffect, useState } from "react";
import "./App.css";
import checkWhite from "./assets/check-white.svg";
import deleteBlack from "./assets/delete-black.svg";
import deleteWhite from "./assets/delete-white.svg";
import editBlack from "./assets/edit-black.svg";
import editWhite from "./assets/edit-white.svg";
import searchWhite from "./assets/search-white.svg";
import ReactDOM from "react-dom";
import Modal from "react-modal";

function App() {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isEditing, setIsEditing] = useState(false);
  const [taskTitle, setTaskTitle] = useState("");
  const [taskFilter, setTaskFilter] = useState("");
  const [taskToEdit, setTaskToEdit] = useState({});
  const [tasks, setTasks] = useState([
    {
      id: 0,
      title: "Criar 500 lorem ipsums",
      marked: false,
    },
  ]);

  useEffect(() => {
    console.log(tasks);
  }, [isModalOpen]);

  function ToggleTaskMark(id, newValue) {
    setTasks(tasks.map((x) => (x.id === id ? { ...x, marked: newValue } : {})));
  }

  function RemoveTask(id) {
    setTasks(tasks.filter((task) => task.id !== id));
  }

  function OpenEditModal(task) {
    setTaskToEdit(task);
    setIsModalOpen(true);
    setIsEditing(true);
    setTaskTitle(task.title);
  }

  function HandleEdit() {
    if (taskTitle !== null) {
      setTasks(
        tasks.map((x) =>
          x.id === taskToEdit.id ? { ...x, title: taskTitle } : {}
        )
      );
      setIsModalOpen(false);
      setIsEditing(false);
      setTaskTitle("");
    }
  }

  function HandleSubmit() {
    console.log(taskTitle);
    if (taskTitle !== null) {
      setTasks([
        ...tasks,
        { id: tasks.length + 1, title: taskTitle, marked: false },
      ]);
      setIsModalOpen(false);
      setTaskTitle("");
    }
    console.log("task");
  }

  return (
    <div className="Container">
      {isModalOpen === false ? (
        <>
          <div className="Main-Box">
            <h1 className="Title">
              Terça-Feira, <span className="Title-Purple">24</span> de Julho
            </h1>
            <div className="Search-Input-Box">
              <img className="Search-Icon" src={searchWhite} />
              <input
                className="Search-Input"
                placeholder="Procurar Tarefa"
                onChange={(x) => setTaskFilter(x.target.value)}
              />
            </div>

            <section className="Task-Section">
              {tasks
                .filter((x) =>
                  x.title.toLowerCase().includes(taskFilter.toLowerCase())
                )
                .map((task) =>
                  task.marked ? (
                    <article className="Task-Box-Marked">
                      <div>
                        <button
                          className="Task-Button-Check-Marked"
                          onClick={() => ToggleTaskMark(task.id, false)}
                        >
                          <img src={checkWhite} />
                        </button>
                      </div>
                      <text className="Task-Text-Marked">{task.title}</text>
                      <div className="Task-Button-Edit-Box">
                        <button
                          className="Task-Button-Edit-Marked"
                          onClick={() => RemoveTask(task.id)}
                        >
                          <img src={deleteWhite} />
                        </button>
                        <button className="Task-Button-Edit-Marked">
                          <img src={editWhite} />
                        </button>
                      </div>
                    </article>
                  ) : (
                    <article key={task.id} className="Task-Box">
                      <div>
                        <button
                          onClick={() => ToggleTaskMark(task.id, true)}
                          className="Task-Button-Check"
                        />
                      </div>
                      <text className="Task-Text">{task.title}</text>
                      <div className="Task-Button-Edit-Box">
                        <button
                          className="Task-Button-Edit"
                          onClick={() => RemoveTask(task.id)}
                        >
                          <img src={deleteBlack} />
                        </button>
                        <button
                          className="Task-Button-Edit"
                          onClick={() => OpenEditModal(task)}
                        >
                          <img src={editBlack} />
                        </button>
                      </div>
                    </article>
                  )
                )}
            </section>
          </div>
          <button
            className="New-Task-Button"
            onClick={() => setIsModalOpen(true)}
          >
            <text className="New-Task-Button-Text">Nova Tarefa</text>
          </button>
        </>
      ) : (
        <div className="Modal-Box">
          <text className="Modal-Title">Descreva sua tarefa</text>
          <textarea
            className="Modal-Text-Area"
            placeholder="Exemplo de descrição"
            onChange={(x) => setTaskTitle(x.target.value)}
            value={taskTitle}
          ></textarea>
          <button
            className="Modal-Button"
            onClick={() => (isEditing ? HandleEdit() : HandleSubmit())}
          >
            <text className="New-Task-Button-Text">Confirmar Tarefa</text>
          </button>
        </div>
      )}
    </div>
  );
}

export default App;
