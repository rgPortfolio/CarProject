import React from 'react'
import { CarSelect } from './CarSelect';
import Header from './Header';

export const Dashboard: React.FC = ({}) => {
        return (
            <div>
            <Header />
            <CarSelect />
            </div>
        );
}