<script lang="ts">
	import { api } from '../../api/api';
	import { onMount } from 'svelte';
	import type { User } from '../../api/client';
	import Field from './field.svelte';

	let inputDemo = '';
	let users: User[] = [];

	onMount(async () => {
		await getUsers();
	});

	async function getUsers() {
		let res = await api.user.getAllUser();
		users = res.data;
	}

	async function createUser() {
		let user: User = {
			username: username,
			password: password
		};
		await api.user.createUser(user);
		await getUsers();
		inputDemo = '';
	}

	let username = '';
	let password = '';

	let has_username_error = false;
	let has_password_error = false;

	let username_error = '';
	let password_error = '';

	function onSubmit() {
		if (validate()) {
			createUser();
		}
	}

	function validate(): boolean {
		let valid = true;
		if (username === '') {
			valid = false;
			username_error = "Username can't be null";
			has_username_error = true;
		} else {
			has_password_error = false;
		}

		if (password === '') {
			valid = false;
			password_error = "password can't be null";
			has_password_error = true;
		} else {
			has_username_error = false;
		}

		return valid;
	}
</script>

<div>
	<form class="m-8 space-y-4 card p-4" on:submit={onSubmit}>
		<Field name="Username" value={username} />
		<label class="label">
			<span>Input</span>
			<input
				class={has_password_error ? 'input input-error' : 'input'}
				type="text"
				placeholder="Password"
				bind:value={password}
			/>
			<div class="text-red-600">
				{password_error}
			</div>
		</label>

		<button class="btn" type="submit">Submit</button>
	</form>

	{#each users as user}
		<div>
			User: {user.username}
			Password: {user.password}
		</div>
	{/each}
</div>
