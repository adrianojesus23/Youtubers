import React from 'react'; // Certifique-se de que React está importado
import '../src/styles/Styles.css';
import { VehicleProvider } from "./context/VehicleContext";
import VehicleForm from "./components/VehicleForm";
import VehicleList from "./components/VehicleList";
import { BrowserRouter as Router } from "react-router-dom";

function App() {
    return (
        <VehicleProvider>
            <Router>
                <div className="container"> 
                    <h1>List of vehicles</h1>
                    <VehicleForm />
                    <VehicleList />
                </div>
            </Router>
        </VehicleProvider>
    );
}

export default App;
