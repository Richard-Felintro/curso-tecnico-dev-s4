import "./App.css";

function App() {
  return (
    <div className="Container">
      <div className="Main-Box">
        <h1 className="Title">
          Terça-Feira, <span className="Title-Purple">24</span> de Julho
        </h1>
        <div className="Search-Input-Box">
          <input className="Search-Input" placeholder="Procurar Tarefa"></input>
        </div>

        <section className="Task-Section">
          <article className="Task-Box">
            <div>
              <button className="Task-Button-Check"></button>
            </div>
            <text className="Task-Text">Criar 500 lorem ipsums</text>
            <div className="Task-Button-Edit-Box">
              <button className="Task-Button-Edit"></button>
              <button className="Task-Button-Edit"></button>
            </div>
          </article>
        </section>
      </div>
      <button className="New-Task-Button">
        <text className="New-Task-Button-Text">Nova Tarefa</text>
      </button>
      <modal className="Create-Task-Modal">
      
      </modal>
    </div>
  );
}

export default App;
