export const convertDateToReadableFormat = (dateString: string) => {
    const date = new Date(dateString);
    const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    const formattedDate = `${months[date.getMonth()]} ${date.getDate()} @ ${date.getHours() % 12 || 12}:${("0" + date.getMinutes()).slice(-2)}${date.getHours() >= 12 ? 'pm' : 'am'}`;
    return formattedDate;
}