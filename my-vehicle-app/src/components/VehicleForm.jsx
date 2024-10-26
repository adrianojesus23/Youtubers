import React, { useState } from 'react'; // Importando React junto com useState
import { useVehicleContext } from "../context/VehicleContext";

const VehicleForm = () => {
    const [code, setCode] = useState("");
    const [country, setCountry] = useState("");

    const { dispatch } = useVehicleContext();

    const handleSubmit = (e) => {
        e.preventDefault();
        if (code.trim() !== "" || country.trim() !== "") {
            dispatch({
                type: "ADD_Vehicle", payload: {
                    id: Date.now(), code, country, completed: true
                }
            })
        }
    }

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                value={code}
                onChange={(e) => setCode(e.target.value)}
                placeholder="Code"
            />
            <input
                type="text"
                value={country}
                onChange={(e) => setCountry(e.target.value)}
                placeholder="Country"
            />
            <button type="submit">Add</button>
        </form>
    );
}

export default VehicleForm;
