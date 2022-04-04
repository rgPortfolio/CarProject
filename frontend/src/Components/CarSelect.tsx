import {
  Button,
  FormControl,
  InputLabel,
  makeStyles,
  MenuItem,
  Select,
} from "@material-ui/core";
import React, { useEffect, useState } from "react";
import { Car } from "../Models/car";
import { getCars } from "../api/Car/CarService";
import { Link } from "@reach/router";

const useStyles = makeStyles((theme) => ({
  formControl: {
    margin: theme.spacing(1),
    minWidth: 120,
  },
  selectEmpty: {
    marginTop: theme.spacing(2),
  },
  centerFlex: {
    display: "flex",
    justifyContent: "center",
  },
}));

export const CarSelect: React.FC = () => {
  const classes = useStyles();

  const [selectedCar, setSelectedCar] = useState("123456");
  const [cars, setCars] = useState([] as Array<Car>);

  const handleChange = (event: { target: { value: any } }) => {
    setSelectedCar(event.target.value);
  };

  useEffect(() => {
    async function getCarsFromApi() {
      setCars(await getCars());
    }
    getCarsFromApi();
  }, []);

  return (
    <div>
      <div className={classes.centerFlex}>
        <FormControl className={classes.formControl}>
          <InputLabel data-test-key={"selectACar"}>Select A Car</InputLabel>
          <Select id="carSelect" value={selectedCar} onChange={handleChange}>
            {cars &&
              cars.map((car: Car) => {
                return (
                  <MenuItem key={car.Id} value={car.Id} data-test-key={car.Id}>
                    {`${car.Make} ${car.Model} ${car.Year}`}
                  </MenuItem>
                );
              })}
          </Select>
        </FormControl>
      </div>
      <div className={classes.centerFlex}>
        <Link to={`car/${selectedCar}`}>
          <Button variant="contained" color="primary">
            Submit
          </Button>
        </Link>
      </div>
    </div>
  );
};
