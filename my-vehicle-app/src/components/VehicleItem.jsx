import React from 'react';
import { useVehicleContext } from "../context/VehicleContext";
import '../styles/Styles.css';

const VehicleItem = ({ vehicle }) => {
    const { dispatch } = useVehicleContext();

    return (
        <div className={`vehicle-item ${vehicle.completed ? "completed" : ""}`}>
            <span>{vehicle.code}</span>
            <span>{vehicle.country}</span>
            <button onClick={() => dispatch({ type: "TOGGLE_Vehicle", payload: vehicle.id })}>
                {vehicle.completed ? "UnCompleted" : "Completed"}
            </button>
            <button onClick={() => dispatch({ type: "DELETE_Vehicle", payload: vehicle.id })}>
                Delete
            </button>
        </div>
    );
}

export default VehicleItem;
