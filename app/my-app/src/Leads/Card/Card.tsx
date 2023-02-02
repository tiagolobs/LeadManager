import { Box, Divider, makeStyles, Paper, Typography } from "@material-ui/core";
import React from "react";
import CardButtons from "./CardButtons";
import CardHeader from "./CardHeader";
import CardInfo from "./CardInfo";

const useStyles = makeStyles((theme) => ({
  paper: {
    background: "white",
    padding: "10px",
    margin: "30px 0",
  },
  text: {
    padding: theme.spacing(2),
  },
}));

interface Props {
  name: string;
  date: string;
  location: string;
  jobCategory: string;
  leadId: number;
  description: string;
  price: number;
  handleUpdate: (id: number, accepted: boolean) => void;
}

const Card: React.FC<Props> = ({
  name,
  date,
  location,
  jobCategory,
  leadId,
  description,
  price,
  handleUpdate,
}) => {
  const classes = useStyles();
  return (
    <Paper className={classes.paper}>
      <CardHeader name={name} date={date}></CardHeader>
      <Divider />
      <CardInfo
        location={location}
        jobCategory={jobCategory}
        leadId={leadId}
      ></CardInfo>

      <Divider />
      <Box className={classes.text}>
        <Typography variant="body2">{description}</Typography>
      </Box>
      <Divider />
      <CardButtons
        price={price}
        leadId={leadId}
        handleUpdate={handleUpdate}
      ></CardButtons>
    </Paper>
  );
};

export default Card;
