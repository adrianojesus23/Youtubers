import React from 'react';
import { useVehicleContext } from "../context/VehicleContext";
import VehicleItem from "./VehicleItem";

const VehicleList = () => {
    const { state } = useVehicleContext();

    return (
        <div>
            {state.vehicles.map((vehicle) => (
                <VehicleItem key={vehicle.id} vehicle={vehicle} /> // Adicionado retorno explícito com parênteses
            ))}
        </div>
    );
}

export default VehicleList;
