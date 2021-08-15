import {
  List,
  ListSubheader,
  ListItem,
  ListItemText,
  makeStyles,
} from "@material-ui/core";
import React, { useEffect } from "react";
import { useState } from "react";
import { getCar } from "../api/Car/CarService";
import { Car } from "./../Models/car";

const useStyles = makeStyles((theme) => ({
  root: {
    width: "100%",
    maxWidth: 360,
    backgroundColor: theme.palette.background.paper,
  },
  nested: {
    paddingLeft: theme.spacing(4),
  },
}));

interface CarProfileProps {
  id?: string;
}

export const CarProfile: React.FC<CarProfileProps> = ({ id }) => {
  const [car, setCar] = useState({} as Car);
  const classes = useStyles();

//   useEffect(() => {
//     async function getCarsFromApi() {
//       setCar(await getCar(id as string));
//     }
//     getCarsFromApi();
//   }, [id]);


  return (
    <List
      component="nav"
      aria-labelledby="nested-list-subheader"
      subheader={
        <ListSubheader component="div" id="nested-list-subheader">
          {`${car.Make} ${car.Model} ${car.Year}`}
        </ListSubheader>
      }
      className={classes.root}
    >
      <ListItem button>
        <ListItemText primary="Engine" />
      </ListItem>
      <ListItem button>
        <ListItemText primary="Interior" />
      </ListItem>
      <ListItem button>
        <ListItemText primary="Exterior" />
      </ListItem>
      <ListItem button>
        <ListItemText primary="Safety" />
      </ListItem>
    </List>
  );
};
